using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength (5, ErrorMessage = "Title must be min 5 char")]
        [MaxLength (280, ErrorMessage ="Title cannot be ove 280 char")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength (5, ErrorMessage = "Content must be min 5 char")]
        [MaxLength (280, ErrorMessage ="Content cannot be ove 280 char")]
        public string Content { get; set; } = string.Empty;

        internal object ToComment()
        {
            throw new NotImplementedException();
        }
    }
}