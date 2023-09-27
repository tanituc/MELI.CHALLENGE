FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR Challenge.API

EXPOSE 5172

#COPY PROJECT FILES
COPY Challenge.sln .
COPY Challenge.API/*.csproj ./Challenge.API/
COPY Challenge.Data/*.csproj ./Challenge.Data/
COPY Challenge.ExternalServices/*.csproj ./Challenge.ExternalServices/
COPY Challenge.Service/*.csproj ./Challenge.Service/
COPY Challenge.Shared/*.csproj ./Challenge.Shared/
COPY Challenge.Test/*.csproj ./Challenge.Test/
COPY Challenge.ToolKit/*.csproj ./Challenge.ToolKit/
RUN dotnet restore


#COPY EVERYTHING ELSE
COPY . .
COPY Challenge.API/.env .env
COPY Challenge.API/.env Challenge.API/
RUN dotnet publish -c Release -o out

#Build Image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /Challenge.API
COPY --from=build /Challenge.API/out .
ENTRYPOINT ["dotnet", "Challenge.API.dll"]