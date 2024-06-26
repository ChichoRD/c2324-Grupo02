using System;
using System.Threading.Tasks;
using TerrainSystem.Requester;
using UnityEngine;

namespace TerrainSystem.Requestable.Retriever.Component
{
    [Serializable]
    public struct TerrainRawDataRetriever : ITerrainDataRetriever<PositionedTerrainRawData>
    {
        internal TerrainRawDataRetriever(TerrainModificationRequester terrainModificationRequester)
        {
            TerrainModificationRequester = terrainModificationRequester;
        }

        [field: SerializeField]
        internal TerrainModificationRequester TerrainModificationRequester { get; private set; }

        public readonly Task<bool> TryRetrieve(in PositionedTerrainRawData destination) =>
            TerrainModificationRequester.TryRetrieve(destination);

        public readonly Task<PositionedTerrainRawData> Retrieve() =>
            ((ITerrainDataRetriever<PositionedTerrainRawData>)TerrainModificationRequester).Retrieve();
    }
}