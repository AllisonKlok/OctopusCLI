﻿using System;
using Octopus.Cli.Util;
using Octopus.Client;

namespace Octopus.Cli.Importers
{
    public interface IImporterLocator
    {
        IImporterMetadata[] List();
        IImporter Find(string name, IOctopusAsyncRepository repository, IOctopusFileSystem fileSystem, ICommandOutputProvider commandOutputProvider);
    }
}
