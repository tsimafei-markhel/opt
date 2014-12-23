using opt.DataModel;

namespace opt.Helpers
{
    /// <summary>
    /// Grants application-wide access to an <see cref="IdentificationModel"/> instance
    /// </summary>
    /// <remarks>Implements Singleton pattern</remarks>
    public sealed class ModelStorage
    {
        /// <summary>
        /// Gets or sets <see cref="IdentificationModel"/> instance
        /// </summary>
        public IdentificationModel Model { get; set; }

        private static ModelStorage instance;
        private static object syncRoot = new object();

        private ModelStorage()
        {
            Model = new IdentificationModel();
        }

        /// <summary>
        /// Gets <see cref="ModelStorage"/> instance
        /// </summary>
        public static ModelStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ModelStorage();
                        }
                    }
                }

                return instance;
            }
        }
    }
}