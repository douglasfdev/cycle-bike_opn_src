#!/bin/bash

echo "=== CycleBike gRPC Adapter Deployment Script ==="
echo ""

# Check if docker is installed
if ! command -v docker &> /dev/null; then
    echo "Docker is not installed. Please install Docker first."
    exit 1
fi

# Check if docker-compose is installed
if ! command -v docker-compose &> /dev/null; then
    echo "Docker Compose is not installed. Please install Docker Compose first."
    exit 1
fi

echo "1. Building CycleBike gRPC adapter..."
docker-compose -f docker-compose.grpc.yaml build grpc-server

echo ""
echo "2. Starting CycleBike gRPC adapter..."
docker-compose -f docker-compose.grpc.yaml up -d grpc-server

echo ""
echo "3. Checking gRPC server status..."
sleep 5

if curl -f http://localhost:8081/health &> /dev/null; then
    echo "✅ gRPC server is running on port 8081"
else
    echo "⚠️  gRPC server health check failed, but server might be starting up..."
fi

echo ""
echo "4. Running client example..."
echo "You can run the client example with:"
echo "   cd src/adapters/CycleBike.Adapters.gRPC.Examples"
echo "   dotnet run"
echo ""
echo "5. View logs:"
echo "   docker-compose -f docker-compose.grpc.yaml logs -f grpc-server"
echo ""
echo "6. Stop services:"
echo "   docker-compose -f docker-compose.grpc.yaml down"
echo ""
echo "Deployment completed! 🚀"