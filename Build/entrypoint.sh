#!/bin/bash

set -e
run_cmd="dotnet run --configuration Release --server.urls http://0.0.0.0:5005 --project ./WhatIsElasticSearch\WhatIsElasticSearch.MvcWebUI/WhatIsElasticSearch.MvcWebUI.csproj"

#until dotnet ef database update; do
#>&2 echo "SQL Server is starting up"
#sleep 1
#done
#>&2 echo "SQL Server is up - executing command"

exec $run_cmd