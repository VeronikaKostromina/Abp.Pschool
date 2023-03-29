using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Pschool.Permissions;
using Abp.Pschool.Students;
using Abp.Pschool.Teachers;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace Abp.Pschool.Blazor.Pages
{
    public partial class Teachers
    {
        private IReadOnlyList<TeacherDto> TeacherList { get; set; }
        private IReadOnlyList<StudentDto> StudentList { get; set; }

        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentTeacherPage { get; set; }
        private string CurrentTeacherSorting { get; set; }
        private int CurrentStudentPage { get; set; }
        private string CurrentStudentSorting { get; set; }

        private int TotalTeacherCount { get; set; }
        private int TotalStudentCount { get; set; }

        private bool CanCreateTeacher { get; set; }
        private bool CanEditTeacher { get; set; }
        private bool CanDeleteTeacher { get; set; }

        private CreateTeacherDto NewTeacher { get; set; }

        private Guid EditingTeacherId { get; set; }
        private Guid CurrentTeacherId { get; set; }

        private UpdateTeacherDto EditingTeacher { get; set; }

        private Modal CreateTeacherModal { get; set; }
        private Modal EditTeacherModal { get; set; }
        private Modal StudentListModal { get; set; }

        private Validations CreateValidationsRef;

        private Validations EditValidationsRef;

        public Teachers()
        {
            NewTeacher = new CreateTeacherDto();
            EditingTeacher = new UpdateTeacherDto();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await GetTeachersAsync();
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateTeacher = await AuthorizationService
                .IsGrantedAsync(PschoolPermissions.Teachers.Create);

            CanEditTeacher = await AuthorizationService
                .IsGrantedAsync(PschoolPermissions.Teachers.Edit);

            CanDeleteTeacher = await AuthorizationService
                .IsGrantedAsync(PschoolPermissions.Teachers.Delete);
        }

        private async Task GetTeachersAsync()
        {
            var result = await TeacherAppService.GetListAsync(
                new GetTeacherListDto
                {
                    MaxResultCount = PageSize,
                    SkipCount = CurrentTeacherPage * PageSize,
                    Sorting = CurrentTeacherSorting
                }
            );

            TeacherList = result.Items;
            TotalTeacherCount = (int)result.TotalCount;
        }

        private async Task OnDataGridReadTeachersAsync(DataGridReadDataEventArgs<TeacherDto> e)
        {
            CurrentTeacherSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentTeacherPage = e.Page - 1;

            await GetTeachersAsync();

            await InvokeAsync(StateHasChanged);
        }

        private void OpenCreateTeacherModal()
        {
            CreateValidationsRef.ClearAll();

            NewTeacher = new CreateTeacherDto();
            CreateTeacherModal.Show();
        }

        private void CloseCreateTeacherModal()
        {
            CreateTeacherModal.Hide();
        }

        private void OpenEditTeacherModal(TeacherDto teacher)
        {
            EditValidationsRef.ClearAll();

            EditingTeacherId = teacher.Id;
            EditingTeacher = ObjectMapper.Map<TeacherDto, UpdateTeacherDto>(teacher);
            EditTeacherModal.Show();
        }

        private async Task DeleteTeacherAsync(TeacherDto teacher)
        {
            var confirmMessage = L["TeacherDeletionConfirmationMessage", teacher.FirstName!];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await TeacherAppService.DeleteAsync(teacher.Id);
            await GetTeachersAsync();
        }

        private void CloseEditTeacherModal()
        {
            EditTeacherModal.Hide();
        }

        private async Task CreateTeacherAsync()
        {
            if (await CreateValidationsRef.ValidateAll())
            {
                await TeacherAppService.CreateAsync(NewTeacher);
                await GetTeachersAsync();
                await CreateTeacherModal.Hide();
            }
        }

        private async Task UpdateTeacherAsync()
        {
            if (await EditValidationsRef.ValidateAll())
            {
                await TeacherAppService.UpdateAsync(EditingTeacherId, EditingTeacher);
                await GetTeachersAsync();
                await EditTeacherModal.Hide();
            }
        }

        private async void OpenStudentListModal(TeacherDto teacher)
        {
            CurrentTeacherId = teacher.Id;
            await GetStudentsAsync();
            StudentListModal.Show();
        }

        private void CloseStudentListModal()
        {
            StudentListModal.Hide();
        }

        private async Task GetStudentsAsync()
        {
            var result = await TeacherAppService.GetStudentListForCurrentTeacher(CurrentTeacherId,
                new GetStudentListDto
                {
                    MaxResultCount = PageSize,
                    SkipCount = CurrentStudentPage * PageSize,
                    Sorting = CurrentStudentSorting
                });

            StudentList = result.Items;
            TotalStudentCount = (int)result.TotalCount;
        }

        private async Task OnDataGridReadStudentsAsync(DataGridReadDataEventArgs<StudentDto> e)
        {
            CurrentStudentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentStudentPage = e.Page - 1;

            await GetStudentsAsync();

            await InvokeAsync(StateHasChanged);
        }
    }
}
