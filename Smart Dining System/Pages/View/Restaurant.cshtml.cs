using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Smart_Dining_System.Pages.View
{

    public class RestaurantModel : PageModel
    {
        public List<Restaurant> listRestaurant = new List<Restaurant>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=11114\\SQLEXPRESS;Initial Catalog=restaurant;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                String sql = "select * from restaurant";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Restaurant restaurant = new Restaurant();
                    restaurant.Id = reader.GetInt32(0);
                    restaurant.Name = reader.GetString(1);
                    restaurant.Description = reader.GetString(2);
                    restaurant.Image = "banner_" + restaurant.Id;
                    listRestaurant.Add(restaurant);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

    }
}
