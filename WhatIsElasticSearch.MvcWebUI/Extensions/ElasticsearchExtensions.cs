using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Diagnostics;
using System.Text;

namespace WhatIsElasticSearch.MvcWebUI.Extensions
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            Uri uri = new Uri(configuration["Elasticsearch:URI"].ToString());
            string defaultIndex = configuration["Elasticsearch:IndexName"];

            var settings = new ConnectionSettings(uri).DefaultIndex(defaultIndex)
                                                      .PrettyJson()
                                                      .DisableDirectStreaming()
                                                      .OnRequestCompleted((details) =>
                                                      {
                                                          if (details.RequestBodyInBytes != null)
                                                              Debug.WriteLine(Encoding.UTF8.GetString(details.RequestBodyInBytes));
                                                          else
                                                              Debug.WriteLine("No request body");
                                                      });

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
