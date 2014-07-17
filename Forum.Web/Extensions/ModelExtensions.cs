﻿using System.Collections.Generic;
using Forum.QueryServices.DTOs;
using Forum.Web.Models;

namespace Forum.Web.Extensions
{
    public static class ModelExtensions
    {
        public static PostListModel ToListViewModel(this PostInfo postInfo)
        {
            var model = new PostListModel();
            model.Id = postInfo.Id;
            model.Subject = postInfo.Subject;
            model.SectionId = postInfo.SectionId;
            model.AuthorId = postInfo.AuthorId;
            model.AuthorName = string.IsNullOrEmpty(postInfo.AuthorName) ? postInfo.AuthorId : postInfo.AuthorName;
            model.CreatedOn = postInfo.CreatedOn.ToString("MM-dd HH:mm");
            model.ReplyCount = postInfo.ReplyCount;
            if (!string.IsNullOrEmpty(postInfo.MostRecentReplyId))
            {
                model.MostRecentReply = new ReplyModel
                {
                    Id = postInfo.MostRecentReplyId,
                    AuthorId = postInfo.MostRecentReplierId,
                    AuthorName = string.IsNullOrEmpty(postInfo.MostRecentReplierName) ? postInfo.MostRecentReplierId : postInfo.MostRecentReplierName,
                    CreatedOn = postInfo.MostRecentReplyCreatedOn.ToString("MM-dd HH:mm")
                };
            }

            return model;
        }
        public static PostDetailModel ToDetailViewModel(this PostInfo postInfo)
        {
            var model = new PostDetailModel();
            if (postInfo == null)
            {
                return model;
            }

            model.Id = postInfo.Id;
            model.Subject = postInfo.Subject;
            model.Body = postInfo.Body;
            model.AuthorId = postInfo.AuthorId;
            model.AuthorName = string.IsNullOrEmpty(postInfo.AuthorName) ? postInfo.AuthorId : postInfo.AuthorName;
            model.CreatedOn = postInfo.CreatedOn.ToString("MM-dd HH:mm");
            model.ReplyCount = postInfo.ReplyCount;
            if (postInfo.ReplyList != null)
            {
                var replyList = new List<ReplyModel>();
                foreach (var reply in postInfo.ReplyList)
                {
                    var replyModel = new ReplyModel
                    {
                        Id = reply.Id,
                        Body = reply.Body,
                        AuthorId = reply.AuthorId,
                        AuthorName = reply.AuthorName,
                        CreatedOn = reply.CreatedOn.ToString("MM-dd HH:mm"),
                        Floor = reply.Floor
                    };
                    replyList.Add(replyModel);
                }
                model.Replies = replyList;
            }

            return model;
        }
        public static SectionModel ToViewModel(this SectionInfo sectionInfo, string currentSectionId)
        {
            var model = new SectionModel();
            if (sectionInfo == null)
            {
                return model;
            }

            model.Id = sectionInfo.Id;
            model.Name = sectionInfo.Name;
            model.IsActive = sectionInfo.Id == currentSectionId;

            return model;
        }
    }
}