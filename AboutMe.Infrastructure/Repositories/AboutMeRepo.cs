using AboutMe.Domain.Abstract;
using AboutMe.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AboutMe.Infrastructure.Repositories
{
    public class AboutMeRepo : IAboutMeRepo
    {
        #region Global Variables
        IConfiguration Config;
        IHostEnvironment HostEnvironment;
        const string aboutMeFileKey = "AboutMeDataFile";
        const string fileFolder = "Content";
        #endregion

        #region Constructors
        public AboutMeRepo(IConfiguration config, IHostEnvironment hostEnvironment)
        {
            Config = config;
            HostEnvironment = hostEnvironment;
        }
        #endregion

        #region Methods
        /// <summary>
        /// GetAboutMe method will get the data from json file and returns the data about me.
        /// </summary>
        /// <returns></returns>
        public async Task<MyInfo> GetAboutMe()
        {
            try
            {
                string aboutMeFileName = Config[aboutMeFileKey];
                string rootFolder = HostEnvironment.ContentRootPath;
                string fullFileName = Path.Combine(rootFolder, fileFolder, aboutMeFileName);
                var info = ReadDataFile<MyInfo>(fullFileName);
                return await Task.FromResult(info);
            }
            catch (Exception ex)
            {
                //log error.
                throw ex;
            }
        }

        /// <summary>
        /// Take the file name as input and reads the file content and gives us the converted data.
        /// </summary>
        /// <typeparam name="T">Return type class should be sent here.</typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        private T ReadDataFile<T>(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    var jsonContent = File.ReadAllText(filename);
                    var configContent = JsonConvert.DeserializeObject<T>(jsonContent);
                    return configContent;
                }
                else
                {
                    throw new Exception("Json file not found.");
                }
            }
            catch (Exception ex)
            {
                //log error.
                throw ex;
            }
        }
        #endregion
    }
}
