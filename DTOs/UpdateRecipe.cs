namespace RecipeAPI.DTOs
{
    public class UpdateRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
    }
}

