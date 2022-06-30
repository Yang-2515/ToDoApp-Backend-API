
using AutoMapper;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.Assignment;
using ToDoApp.Domain.Models.Attackment;
using ToDoApp.Domain.Models.Board;
using ToDoApp.Domain.Models.BoardMember;
using ToDoApp.Domain.Models.Label;
using ToDoApp.Domain.Models.ListTask;
using ToDoApp.Domain.Models.Task;
using ToDoApp.Domain.Models.TaskLabel;
using ToDoApp.Domain.Models.User;

namespace ToDoApp.Service
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Label, LabelResponse>();
            CreateMap<LabelRequest, Label>();
            CreateMap<LabelRequest, LabelResponse>();
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<UserRequest, UserResponse>();
            CreateMap<Assignment, AssignmentResponse>();
            CreateMap<AssignmentRequest, Assignment>();
            CreateMap<AssignmentRequest, AssignmentResponse>();
            CreateMap<Task, TaskResponse>();
            CreateMap<Task, TaskDetail>();
            CreateMap<TaskRequest, Task>();
            CreateMap<TaskRequest, TaskResponse>();
            CreateMap<Task, TaskViewModel>();
            CreateMap<TaskLabel, TaskLabelResponse>();
            CreateMap<TaskLabelRequest, TaskLabel>();
            CreateMap<TaskLabelRequest, TaskLabelResponse>();
            CreateMap<Attackment, AttackmentResponse>();
            CreateMap<AttackmentRequest, Attackment>();
            CreateMap<AttackmentRequest, AttackmentResponse>();
            CreateMap<ListTask, ListTaskResponse>();
            CreateMap<ListTaskRequest, ListTask>();
            CreateMap<ListTaskRequest, ListTaskResponse>();
            CreateMap<ListTask, ListTaskDetail>();
            CreateMap<Board, BoardResponse>();
            CreateMap<Board, BoardDetail>();
            CreateMap<BoardRequest, Board>();
            CreateMap<BoardRequest, BoardResponse>();
            CreateMap<BoardMember, BoardMemberResponse>();
            CreateMap<BoardMemberRequest, BoardMember>();
            CreateMap<BoardMemberRequest, BoardMemberResponse>();
        }
    }
}
