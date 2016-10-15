using System;
using System.IO;

namespace opt.Helpers
{
    /// <summary>
    /// Stores different helper routines for path handling
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Resolves relative path to the absolute (rooted) path against 
        /// <see cref="Environment.CurrentDirectory"/>
        /// </summary>
        /// <param name="relativePath">Path to be resolved</param>
        /// <returns>Null if <paramref name="relativePath"/> is null. <paramref name="relativePath"/>
        /// if it is already rooted. In other cases - full (rooted) path to it</returns>
        public static string ResolveRelativePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                // Not throwing here
                return null;
            }

            return ResolveRelativePath(relativePath, null);
        }

        /// <summary>
        /// Resolves relative path to the absolute (rooted) path
        /// </summary>
        /// <param name="relativePath">Path to be resolved</param>
        /// <param name="currentDirectory">Directory (rooted) to resolve <paramref name="relativePath"/>
        /// against. If this argument is null - <see cref="Environment.CurrentDirectory"/> will be used</param>
        /// <returns>Null if <paramref name="relativePath"/> is null. <paramref name="relativePath"/>
        /// if it is already rooted. In other cases - full (rooted) path to it</returns>
        public static string ResolveRelativePath(string relativePath, string currentDirectory)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                // Not throwing here
                return null;
            }

            if (Path.IsPathRooted(relativePath))
            {
                // Nothing to resolve
                return relativePath;
            }

            string resolveAgainst = currentDirectory;
            if (string.IsNullOrEmpty(resolveAgainst) ||
                !Path.IsPathRooted(resolveAgainst))
            {
                resolveAgainst = Environment.CurrentDirectory;
            }

            return Path.GetFullPath(Path.Combine(resolveAgainst, relativePath));
        }
    }
}