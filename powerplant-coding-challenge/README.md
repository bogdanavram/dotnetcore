
# Install dotnet core 5.0
 Download and install ASP.NET Core Runtime
 
 https://dotnet.microsoft.com/en-us/download/dotnet/5.0 


# Run and test the project

1. Open a terminal into the root folder of the project

2. dotnet run

3. Open http://localhost:8888/swagger/index.html in webbrowser and use Swagger interface to test the API


# Build and run with docker
docker build -t powerplant-coding-challenge .

docker run -d -p 8888:80 --name myapp powerplant-coding-challenge

Open http://localhost:8888/swagger/index.html in webbrowser

# Run the published image

docker pull bogdanavram/powerplant

docker run -d -p 8888:80 --name myapp bogdanavram/powerplant
