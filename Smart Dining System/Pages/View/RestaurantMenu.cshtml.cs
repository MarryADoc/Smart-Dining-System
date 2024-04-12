using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Smart_Dining_System.Pages.View
{
    public class RestaurantMenuModel : PageModel
    {
        [FromRoute]
        public string id { get; set; }
        public List<RestaurantMenu> listMenu = new List<RestaurantMenu>();

        public void OnGet()
        {
            String connectionString = "Data Source=11114\\SQLEXPRESS;Initial Catalog=restaurant;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            String sql = "select * from restaurant_menu where r_id = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RestaurantMenu restaurantMenu = new RestaurantMenu();
                restaurantMenu.Id = reader.GetInt32(0);
                restaurantMenu.menu_item = reader.GetString(1);
                restaurantMenu.item_description = reader.GetString(2);
                restaurantMenu.item_price = reader.GetInt32(3);
                listMenu.Add(restaurantMenu);
            }

        }
    }
    public class RestaurantMenu
    {
        public int Id {get; set;} 
        public string menu_item { get; set;}
        public string item_description { get; set;}
        public int item_price { get; set;}
    }
}
