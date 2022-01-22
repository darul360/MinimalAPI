using System;
namespace TodoAPI_MinimalAPI.Model
{
	public class Task
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public String Description { get; set; }
		public Boolean IsCompleted { get; set; } = false;

		public Task(String description, Boolean ? isCompleted = null)
		{
			Description = description;
			if(isCompleted != null)
				IsCompleted = (bool)isCompleted;
		}

		public Task() { }
	}
}

