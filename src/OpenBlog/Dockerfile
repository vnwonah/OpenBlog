FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 5500
EXPOSE 5402

COPY *.csproj .
RUN dotnet restore 

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "OpenBlog.dll"]