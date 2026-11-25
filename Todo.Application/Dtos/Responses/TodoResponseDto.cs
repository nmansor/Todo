using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Application.Dtos.Responses
{
    public record TodoResponseDto(
        string Name,
        bool IsCompleted
        //string Description,
      //  List<TodoMetadata>? Metadata
    );

    public record TodoMetadata(
        string Title,
        string Description,
        string Priority,
        string Status,
        DateTime? DueDate
    );
}
