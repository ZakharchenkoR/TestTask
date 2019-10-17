
// static class how has method how filtering collection and return this filtering collection
namespace TasksApplication.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    public static class Filtering
    {
        //static method how filtering collection
        public static IEnumerable<TaskModel> Filter(NotifyCollection<TaskModel> dataToFiltering,string title, DateTime? startData, DateTime? endDate, Condition condition)
        {
            if (title == null && startData == null && endDate == null && condition == Condition.NotFound)
            {
                return dataToFiltering;
            }

            IEnumerable<TaskModel> titleList = dataToFiltering;

            if (!string.IsNullOrWhiteSpace(title))
            {
                titleList = titleList.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
            }

            var startDataList = titleList;

            if (startData != null)
            {
                startDataList = titleList.Where(x => x.StartData == startData).ToList();
            }

            var endDataList = startDataList;

            if (endDate != null)
            {
                endDataList = startDataList.Where(x => x.EndData == endDate).ToList();
            }

            var result = endDataList;

            if (condition != Condition.NotFound)
            {
                result = endDataList.Where(x => x.Condition == condition).ToList();
            }

            return result;
        }
    }
}