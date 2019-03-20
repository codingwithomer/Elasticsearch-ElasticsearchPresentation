using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsElasticSearch.Entities.DTOs
{
    public class IndexResponseDTO
    {
        public bool IsValid { get; set; }
        public string StatusMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
