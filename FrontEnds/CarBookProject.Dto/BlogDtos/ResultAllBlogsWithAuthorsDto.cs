using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorsDto
    {

        public int blogId { get; set; }
        public string blogTitle { get; set; }
        public string authorName { get; set; }
        public string categoryName { get; set; }
        public int authorId { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryId { get; set; }

    }
}
