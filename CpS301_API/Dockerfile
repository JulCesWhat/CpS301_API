# Sample contents of Dockerfile
# Stage 1
FROM microsoft/aspnetcore-build AS builder
WORKDIR /source

# caches restore result by copying csproj file separately
COPY *.csproj .
RUN dotnet restore

# copies the rest of your code
COPY . .
RUN dotnet publish --output /app/ --configuration Release


# Stage 2
FROM microsoft/aspnetcore
ENV connectionStrings:wsoappDBConnectionString
WORKDIR /app
COPY --from=builder /app .
EXPOSE 3038
ENTRYPOINT ["dotnet", "CpS301_API.dll"]