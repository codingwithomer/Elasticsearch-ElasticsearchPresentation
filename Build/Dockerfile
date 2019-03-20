FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
PORT 
EXPOSE 5005/tcp

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WhatIsElasticSearch.MvcWebUI/WhatIsElasticSearch.MvcWebUI.csproj", "WhatIsElasticSearch.MvcWebUI/"]
RUN dotnet restore "WhatIsElasticSearch.MvcWebUI/WhatIsElasticSearch.MvcWebUI.csproj"
COPY . .
WORKDIR "/src/WhatIsElasticSearch.MvcWebUI"
RUN dotnet build "WhatIsElasticSearch.MvcWebUI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WhatIsElasticSearch.MvcWebUI.csproj" -c Release -o /app
RUN mkdir '/app/node_modules'
ADD Northwind.db /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5005
ENTRYPOINT ["dotnet", "WhatIsElasticSearch.MvcWebUI.dll", "--server.urls", "http://*:5005"]