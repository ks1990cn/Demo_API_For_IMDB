#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#This is causing error.... I tried to change path here

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AssignmentDeltaXAPI/AssignmentDeltaXAPI.csproj", "AssignmentDeltaXAPI/"]
COPY ["Security/Security.csproj", "Security/"]
COPY ["NonSchemaModels/NonSchemaModels.csproj", "NonSchemaModels/"]
COPY ["CustomValidation/CustomValidation.csproj", "CustomValidation/"]
RUN dotnet restore "AssignmentDeltaXAPI/AssignmentDeltaXAPI.csproj"
COPY . .
WORKDIR "/src/AssignmentDeltaXAPI"
RUN dotnet build "AssignmentDeltaXAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssignmentDeltaXAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssignmentDeltaXAPI.dll"]