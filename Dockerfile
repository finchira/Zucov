FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /app

COPY Zucov.Api.csproj ./
COPY Zucov.Api.Test/Zucov.Api.Test.csproj ./

RUN dotnet restore

COPY . .


RUN dotnet publish Zucov.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:9.0 as release
WORKDIR /app
	
ENV ASPNET_URLS=http://+:8080

COPY --from=build /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Zucov.Api.dll"]