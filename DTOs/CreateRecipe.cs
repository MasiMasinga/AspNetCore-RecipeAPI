namespace RecipeAPI.DTOs
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public int Duration { get; set; } = 0;

    }
}