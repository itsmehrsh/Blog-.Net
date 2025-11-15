# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# restore
COPY Blog.Web.csproj ./
RUN dotnet restore Blog.Web.csproj

# copy sources and publish the specific project
COPY . .
RUN dotnet publish Blog.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
RUN mkdir -p /app/data
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5208 \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

EXPOSE 5208
ENTRYPOINT ["dotnet", "Blog.Web.dll"]
