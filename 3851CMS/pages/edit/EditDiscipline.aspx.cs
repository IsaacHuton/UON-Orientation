using _3851CMS.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3851CMS.pages.edit
{
    public partial class EditDiscipline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // Get all disciplines from the database
                DataTable dtDisciplines = SQLUtils.GetTable("SELECT * FROM Discipline");

                // Fill the dropdownlist
                ddlDisciplines.DataTextField = "Discipline_Name";
                ddlDisciplines.DataValueField = "Discipline_ID";
                ddlDisciplines.DataSource = dtDisciplines;
                ddlDisciplines.DataBind();
                ddlDisciplines.SelectedIndex = 0;

                DropDownList1.DataTextField = "Discipline_Name";
                DropDownList1.DataValueField = "Discipline_ID";
                DropDownList1.DataSource = dtDisciplines;
                DropDownList1.DataBind();
                DropDownList1.SelectedIndex = 0;
                LoadCourses();
            }
        }
        protected void ddlDisciplines_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }
        protected void LoadCourses()
        {
            // Get the selected discipline id
            string disciplineId = ddlDisciplines.SelectedValue;

            // Get all courses related to the discipline from the database
            DataTable dtCourses = SQLUtils.GetTable($"SELECT Course.Course_ID, Course.Course_Code, Course.Course_Name FROM Course INNER JOIN Discipline_Course ON Course.Course_ID = Discipline_Course.Course_ID WHERE Discipline_Course.Discipline_ID = {disciplineId}");

            // Fill the gridview
            gvCourses.DataSource = dtCourses;
            gvCourses.DataBind();
        }

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string courseId = gvCourses.DataKeys[e.RowIndex].Value.ToString();
            var param = new Dictionary<string, object>()
            {
                { "@Course_ID", courseId }
            };

            //delete course from Discipline_Course table 
            SQLUtils.SQLHandler("DELETE FROM Discipline_Course WHERE Course_ID = @Course_ID", param);

            //load courses after delete
            LoadCourses();
        }
        protected void gvCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCourses.EditIndex = e.NewEditIndex;
            LoadCourses();
        }

        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string courseId = gvCourses.DataKeys[e.RowIndex].Value.ToString();

            // Get the row being edited
            GridViewRow row = gvCourses.Rows[e.RowIndex];

            // Find the controls
            TextBox txtCourseCode = row.FindControl("txtCourseCode") as TextBox;
            TextBox txtCourseName = row.FindControl("txtCourseName") as TextBox;

            // If the controls are found, update the database
            if (txtCourseCode != null && txtCourseName != null)
            {
                string courseCode = txtCourseCode.Text;
                string courseName = txtCourseName.Text;

                var parameters = new Dictionary<string, object>()
                {
                    { "@Course_ID", courseId },
                    { "@Course_Code", courseCode.ToString()},
                    { "@Course_Name", courseName.ToString()}
                };
                SQLUtils.SQLHandler("UPDATE Course SET Course_Code = @Course_Code, Course_Name = @Course_Name WHERE Course_ID = @Course_ID", parameters);

                gvCourses.EditIndex = -1;
                LoadCourses();
            }
        }

        protected void gvCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCourses.EditIndex = -1;
            LoadCourses();
        }

        protected void btnSaveDiscipline_Click(object sender, EventArgs e)
        {
            string disciplineName = txtDisciplineName.Text;
            var param = new Dictionary<string, object>()
            {
                { "@Discipline_Name", disciplineName }
            };
            DataTable dt = SQLUtils.GetTable($"SELECT * FROM Discipline WHERE Discipline_Name = @Discipline_Name", param);
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Discipline Already Exists！');</script>");
                return;
            }
            SQLUtils.SQLHandler("INSERT INTO Discipline (Discipline_Name) VALUES (@Discipline_Name)", param);
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSaveCourse_Click(object sender, EventArgs e)
        {
            string disciplineId = DropDownList1.SelectedValue;
            string courseCode = txtCourseCode.Text;
            string courseName = txtCourseName.Text;
            string courseId = "";
            
            //Get Course ID
            DataTable dt1 = SQLUtils.GetTable($"SELECT Course_ID FROM Course WHERE Course_Code = '{courseCode}'");
            if (dt1.Rows.Count > 0)
            {
                courseId = dt1.Rows[0]["Course_ID"].ToString();
            }

            // Use Course ID to check if the course already exists in the discipline
            string query = "SELECT * FROM Discipline_Course WHERE Course_ID = @CourseID and Discipline_ID = @DisciplineId";
            var parameters = new Dictionary<string, object>
            {
                { "@CourseID", courseId },
                { "@DisciplineId", disciplineId }
            };

            DataTable dt = SQLUtils.GetTable(query, parameters); 
            //if the course already exists in the discipline
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Course Already Exists in this Descipline！');</script>");
                return;
            }

            var param = new Dictionary<string, object>()
            {
                { "@Course_Code", courseCode },
                { "@Course_Name", courseName }
            };

            // if the course already exists in the database
            // and it does not exist in the discipline
            DataTable dataTable = SQLUtils.GetTable("SELECT Course_ID FROM Course WHERE Course_Code = @Course_Code AND Course_Name = @Course_Name", param);
            if (dataTable.Rows.Count > 0)
            {
                // Get the course id and insert it into the discipline_course table
                courseId = dataTable.Rows[0]["Course_ID"].ToString();
                SQLUtils.SQLHandler("INSERT INTO Discipline_Course (Discipline_ID, Course_ID) VALUES (@Discipline_ID, @Course_ID)",
               new Dictionary<string, object>() { { "@Discipline_ID", disciplineId },{"@Course_ID", courseId } });
            }
            else
            {
                SQLUtils.SQLHandler("INSERT INTO Course (Course_Code, Course_Name) VALUES (@Course_Code, @Course_Name)", param);

                SQLUtils.SQLHandler("INSERT INTO Discipline_Course (Discipline_ID, Course_ID) VALUES (@Discipline_ID, (SELECT MAX(Course_ID) FROM Course))",
                new Dictionary<string, object>() { { "@Discipline_ID", disciplineId } });
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void btnDeleDiscipline_Click(object sender, EventArgs e)
        {

            string disciplineId = ddlDisciplines.SelectedValue;
            var param = new Dictionary<string, object>()
            {
                { "@Discipline_ID", disciplineId }
            };

            SQLUtils.SQLHandler("DELETE FROM Discipline_Course WHERE Discipline_ID = @Discipline_ID", param);

            SQLUtils.SQLHandler("DELETE FROM Discipline WHERE Discipline_ID = @Discipline_ID", param);
            Response.Redirect(Request.RawUrl);
        }
    }
}