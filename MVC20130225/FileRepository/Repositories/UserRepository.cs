﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFileAdapter;
using Entities;
using FileSystemInterfaces;
using TodoRepository.Interfaces;


namespace FileRepository.Repositories
{
    public class UserRepository : BaseFileRepository<User>, IUserRepository
    {
        public UserRepository(string path, IFileInfoFactory fileInfo, IDirectoryInfo directoryInfo) : base(path, fileInfo, directoryInfo)
        {
        }

        protected override string GenerateFileName(User entity)
        {
            return string.Format("{0}/user.json", Path);
        }

        public override User Create(User entity)
        {
            string fileName = GenerateFileName(entity);
            IFileInfo fileInfo = FileInfoFactory.CreateFileInfo(fileName);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            return base.Create(entity);
        }
    }
}
