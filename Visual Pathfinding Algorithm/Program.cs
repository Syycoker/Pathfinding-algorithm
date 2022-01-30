namespace Visual_Pathfinding_Algorithm
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      ApplicationConfiguration.Initialize();
      WrapperForm = new MainMenu();
      Application.Run(WrapperForm);
    }

    /// <summary>
    /// Singleton Implementaion, to get information directly to children without using a delegate, sorry I felt lazy lol.
    /// </summary>
    public static MainMenu? WrapperForm { get; set; }
  }
}