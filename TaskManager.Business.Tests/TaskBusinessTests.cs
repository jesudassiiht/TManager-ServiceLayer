using NBench;
using System.Collections.Generic;
using TaskManager.Business;
using TaskManager.Entities;
using TaskManager.Repositories;
using TaskManager.Business.ServiceRequests;
using System;

namespace TaskManager.Business.Tests
{
    public class TaskBusinessLoadTest
    {
        public TaskBusinessLoadTest()
        {

        }

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            //Mapper.Reset();
        }

        [PerfBenchmark(Description = "***** Result for GetAllParentTask *****",
                                                       NumberOfIterations = 2,
                                                       RunMode = RunMode.Throughput,
                                                       TestMode = TestMode.Measurement, SkipWarmups = false)]

        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void BenchMarkGetAllParentTask()
        {
            IEnumerable<ParentTaskViewModel> parentTasks;
            IRepository<ProjectTask> taskRepository = new Repository<ProjectTask>();
            IRepository<ParentTask> parenttaskRepository = new Repository<ParentTask>();
            IParentTaskBusiness taskbusiness = new ParentTaskBusiness(parenttaskRepository);
            TaskBusiness taskBusiness = new TaskBusiness(taskRepository, taskbusiness);
            parentTasks = taskBusiness.GetAllParentTasks();
        }

        [PerfBenchmark(Description = "***** Result for GetTasks *****",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void BenchMarkGetTasks()
        {
            IEnumerable<TaskViewModel> tasks;
            IRepository<ProjectTask> taskRepository = new Repository<ProjectTask>();
            IRepository<ParentTask> parenttaskRepository = new Repository<ParentTask>();
            IParentTaskBusiness taskbusiness = new ParentTaskBusiness(parenttaskRepository);
            TaskBusiness taskBusiness = new TaskBusiness(taskRepository, taskbusiness);
            tasks = taskBusiness.GetAllTasks();
        }

        [PerfBenchmark(Description = "***** Result for GetTask By ID *****",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void BenchMarkGetTaskById()
        {
            TaskViewModel task;
            IRepository<ProjectTask> taskRepository = new Repository<ProjectTask>();
            IRepository<ParentTask> parenttaskRepository = new Repository<ParentTask>();
            IParentTaskBusiness taskbusiness = new ParentTaskBusiness(parenttaskRepository);
            TaskBusiness taskBusiness = new TaskBusiness(taskRepository, taskbusiness);
            task = taskBusiness.GetById(1);
        }

        [PerfBenchmark(Description = "***** Result for AddTask *****",
                                                        NumberOfIterations = 2,
                                                        RunMode = RunMode.Throughput,
                                                        TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void BenchMarkSaveTask()
        {
            TaskViewModel task = new TaskViewModel
            {
                TaskName = "Task addded from NBench",
                StartDate = Convert.ToDateTime("12/12/2018"),
                ParentTaskId = 1,
                Priority = 15,
                EndDate = Convert.ToDateTime("12/12/2018"),
                TaskId = 0,
                ParentTaskName = string.Empty
            };

            IRepository<ProjectTask> taskRepository = new Repository<ProjectTask>();
            IRepository<ParentTask> parenttaskRepository = new Repository<ParentTask>();
            IParentTaskBusiness taskbusiness = new ParentTaskBusiness(parenttaskRepository);
            TaskBusiness taskBusiness = new TaskBusiness(taskRepository, taskbusiness);
            taskBusiness.Save(task);
        }

        [PerfCleanup]
        public void Cleanup()
        {
        }
    }

}
