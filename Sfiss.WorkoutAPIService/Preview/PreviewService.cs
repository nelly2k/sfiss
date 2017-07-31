using System;
using System.Collections.Generic;
using Sfiss.WorkoutAPIService.Preview.Model;

namespace Sfiss.WorkoutAPIService.Preview
{
    public class PreviewService
    {
        /// <summary>
        /// 1. Get workout from my db
        /// 2. Get list of exercises (brief)
        /// 3. Retrieve all small images
        /// 4. Compile all into collection
        /// </summary>
        /// <param name="guid"></param>
        public List<PreviewItem> GetPreview(Guid guid)
        {
            
            return new List<PreviewItem>();
        }
    }
}
