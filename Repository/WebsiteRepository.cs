﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class WebsiteRepository : RepositoryBase<Website>, IWebsiteRepository
    {
        public WebsiteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public IEnumerable<Website> GetAllWebsites()
        {
            return FindAll().OrderBy(website => website.Name);
        }

        public Website GetWebsiteById(Guid id)
        {
            return FindByCondition(website => website.Id == id).FirstOrDefault();
        }

        public void CreateWebsite(Website website)
        {
            website.Id = Guid.NewGuid();
            Create(website);
            Save();
        }
    }
}