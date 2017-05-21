namespace EFC.BL
{
    /// <summary>
    /// Base properties of a Rendering Provider
    /// </summary>
    public class RenderingProvider: Provider
    {
        public string FullName()
        {
            string fullName = FirstName;

            if (!string.IsNullOrEmpty(LastName))
            {
                fullName = fullName += " " + LastName;
            }
            return fullName;
        }

 
    }
}
