﻿using System;
using ENode.Commanding;

namespace Forum.Commands.Replies
{
    [Serializable]
    public class CreateReplyCommand : Command
    {
        public string PostId { get; private set; }
        public string ParentId { get; private set; }
        public string Body { get; private set; }
        public string AuthorId { get; private set; }

        private CreateReplyCommand() { }
        public CreateReplyCommand(string postId, string parentId, string body, string authorId)
        {
            PostId = postId;
            ParentId = parentId;
            Body = body;
            AuthorId = authorId;
        }
    }
}
