﻿using KrTrade.Nt.DI.Primitives;

namespace KrTrade.Nt.DI.FileProviders
{
    /// <summary>
    /// A read-only file provider abstraction.
    /// </summary>
    public interface IFileProvider
    {
        /// <summary>
        /// Locate a file at the given path.
        /// </summary>
        /// <param name="subpath">Relative path that identifies the file.</param>
        /// <returns>The file information. Caller must check Exists property.</returns>
        IFileInfo GetFileInfo(string subpath);

        /// <summary>
        /// Enumerate a directory at the given path, if any.
        /// </summary>
        /// <param name="subpath">Relative path that identifies the directory.</param>
        /// <returns>Returns the contents of the directory.</returns>
        IDirectoryContents GetDirectoryContents(string subpath);

        /// <summary>
        /// Creates a <see cref="IChangeToken"/> for the specified filter.
        /// </summary>
        /// <param name="filter">Filter string used to determine what files or folders to monitor. Example: **/*.cs,
        /// *.*, subFolder/**/*.cshtml.</param>
        /// <returns>An <see cref="IChangeToken"/> that is notified when a file
        /// matching filter is added, modified or deleted.</returns>
        IChangeToken Watch(string filter);
    }
}
