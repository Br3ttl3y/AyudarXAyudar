using AyudarXAyudar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AyudarXAyudar.App_Code
{
    public class PetImageManager
    {
        private ControllerContext petController;
        private Pet pet;

        private static string PetImageDirectory = @"~\Content\Images\Pets\";

        public PetImageManager(ControllerContext context, Pet pet)
        {
            petController = context;
            this.pet = pet;
        }

        public void DeleteExistingPetImages()
        {
            string petFileSearchPattern = string.Format("{0}.*", pet.Id);
            string[] allPhotosOfThisPet = System.IO.Directory.GetFiles(
                    GetPetImageServerPath(), petFileSearchPattern,
                    System.IO.SearchOption.TopDirectoryOnly);

            if (allPhotosOfThisPet.Length > 0)
            {
                foreach (string pictureFile in allPhotosOfThisPet)
                {
                    System.IO.File.Delete(pictureFile);
                }
            }
        }

        public string GetServerImageFilePath(string fileName)
        {
            string renamedFile = GetPetImageFileName(fileName);
            return GetPhysicalFilePath(renamedFile);
        }

        public string GetUrlContentFilePath(string fileName)
        {
            return PetImageDirectory + GetPetImageFileName(fileName);
        }

        private string GetPhysicalFilePath(string renamedFile)
        {
            return System.IO.Path.Combine(GetPetImageServerPath(), renamedFile);
        }

        private string GetPetImageFileName(string fileName)
        {
            string fileExtension = System.IO.Path.GetExtension(fileName);
            return pet.Id + fileExtension;
        }

        private string GetPetImageServerPath()
        {
            return petController.HttpContext.Server.MapPath(PetImageDirectory);
        }

    }
}