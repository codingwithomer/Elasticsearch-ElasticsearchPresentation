#!/bin/bash
set -e
run_cmd="/usr/bin/dotnet run --configuration Release --server.urls http://0.0.0.0:5005 --project ./WhatIsElasticSearch.MvcWebUI/WhatIsElasticSearch.MvcWebUI.csproj"
exec $run_cmd