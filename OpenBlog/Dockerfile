#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["OpenBlog/OpenBlog.csproj", "OpenBlog/"]
RUN dotnet restore "OpenBlog/OpenBlog.csproj"
COPY . .
WORKDIR "/src/OpenBlog"
RUN dotnet build "OpenBlog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenBlog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenBlog.dll"]