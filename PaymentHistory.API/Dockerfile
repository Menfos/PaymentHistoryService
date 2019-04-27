FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY PaymentHistory.API/PaymentHistory.API.csproj PaymentHistory.API/
RUN dotnet restore PaymentHistory.API/PaymentHistory.API.csproj
COPY . .
WORKDIR /src/PaymentHistory.API
RUN dotnet build PaymentHistory.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PaymentHistory.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentHistory.API.dll"]
