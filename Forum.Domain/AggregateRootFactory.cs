﻿using ECommon.Components;
using ENode.Domain;
using Forum.Domain.Accounts;
using Forum.Domain.Posts;
using Forum.Domain.Replies;
using Forum.Domain.Sections;
using Forum.Infrastructure;

namespace Forum.Domain
{
    [Component]
    public class AggregateRootFactory
    {
        private readonly IIdentityGenerator _identityGenerator;
        private readonly IRepository _repository;

        public AggregateRootFactory(IIdentityGenerator identityGenerator, IRepository repository)
        {
            _identityGenerator = identityGenerator;
            _repository = repository;
        }

        public Account CreateAccount(string name, string password)
        {
            return new Account(_identityGenerator.GetNextIdentity(), name, password);
        }
        public Section CreateSection(string name)
        {
            return new Section(_identityGenerator.GetNextIdentity(), name);
        }
        public Post CreatePost(string subject, string body, string sectionId, string authorId)
        {
            return new Post(_identityGenerator.GetNextIdentity(), subject, body, sectionId, authorId);
        }
        public Reply CreateReply(string postId, string parentId, string authorId, string body)
        {
            Reply parent = null;
            if (!string.IsNullOrEmpty(parentId))
            {
                parent = _repository.Get<Reply>(parentId);
            }
            return new Reply(_identityGenerator.GetNextIdentity(), postId, parent, authorId, body);
        }
    }
}
