using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;
using CycleBike.Adapters.gRPC;
using CycleBike.Adapters.gRPC.Services;
using Grpc.Core;
using Moq;

namespace UnitTest.adapters.gRPC;

public class BicycleGrpcServiceTests
{
    private readonly GrpcService _service;
    private readonly Mock<ICommandHandler<CreateBicycleCommand, Bicycle>> _mockCreateHandler;
    private readonly Mock<IQueryHandler<GetBicycleByIdQuery, Bicycle>> _mockGetByIdHandler;
    private readonly Mock<IQueryHandler<ListBicyclesQuery, PaginatedResult<Bicycle>>> _mockListHandler;
    private readonly ServerCallContext _context;

    public BicycleGrpcServiceTests()
    {
        _mockCreateHandler = new Mock<ICommandHandler<CreateBicycleCommand, Bicycle>>();
        _mockGetByIdHandler = new Mock<IQueryHandler<GetBicycleByIdQuery, Bicycle>>();
        _mockListHandler = new Mock<IQueryHandler<ListBicyclesQuery, PaginatedResult<Bicycle>>>();
        
        _service = new BicycleGrpcService(
            _mockCreateHandler.Object,
            _mockGetByIdHandler.Object,
            _mockListHandler.Object
        );
        
        _context = Mock.Of<ServerCallContext>();
    }

    [Fact]
    public async Task CreateBicycle_WhenSuccess_ReturnsBicycleResponse()
    {
        // Arrange
        var request = new CreateBicycleRequest
        {
            Name = "Test Bike",
            Price = 1000.00,
            Description = "Test description"
        };
        
        var bicycle = new Bicycle(
            "Test Bike",
            1000.00,
            "Test description"
        );
        
        _mockCreateHandler
            .Setup(x => x.HandleAsync(It.IsAny<CreateBicycleCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ApiResult<Bicycle>.Success("Created", bicycle));

        // Act
        var result = await _service.CreateBicycle(request, _context);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bicycle.Name, result.Name);
        Assert.Equal(bicycle.Price, result.Price);
        Assert.Equal(bicycle.Description, result.Description);
    }

    [Fact]
    public async Task CreateBicycle_WhenFailure_ThrowsRpcException()
    {
        // Arrange
        var request = new CreateBicycleRequest
        {
            Name = "Test Bike",
            Price = 1000.00,
            Description = "Test description"
        };
        
        _mockCreateHandler
            .Setup(x => x.HandleAsync(It.IsAny<CreateBicycleCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ApiResult<Bicycle>.Failure("Failed to create bicycle"));

        // Act & Assert
        await Assert.ThrowsAsync<RpcException>(() => 
            _service.CreateBicycle(request, _context));
    }

    [Fact]
    public async Task GetBicycle_WhenSuccess_ReturnsBicycleResponse()
    {
        // Arrange
        var request = new GetBicycleRequest { Id = Guid.NewGuid().ToString() };
        var bicycle = new Bicycle(
            "Test Bike",
            1000.00,
            "Test description"
        );
        
        _mockGetByIdHandler
            .Setup(x => x.HandleAsync(It.IsAny<GetBicycleByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ApiResult<Bicycle>.Success("Found", bicycle));

        // Act
        var result = await _service.GetBicycle(request, _context);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bicycle.Name, result.Name);
        Assert.Equal(bicycle.Price, result.Price);
        Assert.Equal(bicycle.Description, result.Description);
    }

    [Fact]
    public async Task GetBicycle_WhenNotFound_ThrowsRpcException()
    {
        // Arrange
        var request = new GetBicycleRequest { Id = Guid.NewGuid().ToString() };
        
        _mockGetByIdHandler
            .Setup(x => x.HandleAsync(It.IsAny<GetBicycleByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ApiResult<Bicycle>.Failure("Bicycle not found"));

        // Act & Assert
        await Assert.ThrowsAsync<RpcException>(() => 
            _service.GetBicycle(request, _context));
    }
}