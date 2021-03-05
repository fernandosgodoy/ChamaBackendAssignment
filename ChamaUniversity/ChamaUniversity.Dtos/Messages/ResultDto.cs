using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Dtos.Messages
{
    public class ResultDto
    {

        public ResultDto()
        {
            Messages = new List<string>();
        }

        public int InsertedId { get; set; }
        public bool Success { get; set; }
        public List<string> Messages { get; set; }

    }
}
