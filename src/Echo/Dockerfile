ARG DOTNET_SDK=3.1

FROM mcr.microsoft.com/dotnet/core/sdk:${DOTNET_SDK} AS build
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/dist

FROM mcr.microsoft.com/dotnet/core/aspnet:${DOTNET_SDK} as dist
ENV PORT=5000 
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}
WORKDIR /app
COPY --from=build /app/dist .
ENTRYPOINT [ "dotnet", "Echo.dll" ]


