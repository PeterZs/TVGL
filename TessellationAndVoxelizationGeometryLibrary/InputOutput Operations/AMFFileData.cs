﻿// ***********************************************************************
// Assembly         : TessellationAndVoxelizationGeometryLibrary
// Author           : Matt Campbell
// Created          : 02-27-2015
//
// Last Modified By : Matt Campbell
// Last Modified On : 06-05-2014
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using amf;

namespace TVGL.IOFunctions
{
    /// <summary>
    ///     Class AMFFileData.
    /// </summary>
    [XmlRoot("amf")]
     #if help
    internal class AMFFileData : IO
#else                   
    public class AMFFileData : IO
#endif
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AMFFileData" /> class.
        /// </summary>
        public AMFFileData()
        {
            Objects = new List<AMF_Object>();
        }

        /// <summary>
        ///     Gets or sets the objects.
        /// </summary>
        /// <value>The objects.</value>
        [XmlElement("object")]
        public List<AMF_Object> Objects { get; set; }

        /// <summary>
        ///     Gets or sets the textures.
        /// </summary>
        /// <value>The textures.</value>
        [XmlElement("texture")]
        internal List<AMF_Texture> Textures { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public AMF_Unit unit { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [unit specified].
        /// </summary>
        /// <value><c>true</c> if [unit specified]; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool unitSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public double version { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [version specified].
        /// </summary>
        /// <value><c>true</c> if [version specified]; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool versionSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        public string lang { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }



        internal static List<TessellatedSolid> Open(Stream s, bool inParallel = true)
        {
            var now = DateTime.Now;
            AMFFileData amfData;
            // Try to read in BINARY format
            if (AMFFileData.TryUnzippedXMLRead(s, out amfData))
                Debug.WriteLine("Successfully read in AMF file (" + (DateTime.Now - now) + ").");
            else
            {
                // Reset position of stream
                s.Position = 0;
                // Read in ASCII format
                //if (amf.TryZippedXMLRead(s, out amfData))
                //    Debug.WriteLine("Successfully unzipped and read in ASCII OFF file (" + (DateTime.Now - now) + ").");
                //else
                //{
                //    Debug.WriteLine("Unable to read in AMF file (" + (DateTime.Now - now) + ").");
                //    return null;
                //}
            }
            var results = new List<TessellatedSolid>();
            foreach (var amfObject in amfData.Objects)
            {
                List<Color> colors = null;
                if (amfObject.mesh.volume.color != null)
                {
                    colors = new List<Color>();
                    var solidColor = new Color(amfObject.mesh.volume.color);
                    foreach (var amfTriangle in amfObject.mesh.volume.Triangles)
                        colors.Add((amfTriangle.color != null) ? new Color(amfTriangle.color) : solidColor);
                }
                else if (amfObject.mesh.volume.Triangles.Any(t => t.color != null))
                {
                    colors = new List<Color>();
                    var solidColor = new Color(Constants.DefaultColor);
                    foreach (var amfTriangle in amfObject.mesh.volume.Triangles)
                        colors.Add((amfTriangle.color != null) ? new Color(amfTriangle.color) : solidColor);
                }
                results.Add(new TessellatedSolid(amfData.Name,
                    amfObject.mesh.vertices.Vertices.Select(v => v.coordinates.AsArray).ToList(),
                    amfObject.mesh.volume.Triangles.Select(t => t.VertexIndices).ToList(),
                    colors));
            }
            return results;
        }

        /// <summary>
        ///     Tries the unzipped XML read.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="amfFileData">The amf file data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal static bool TryUnzippedXMLRead(Stream stream, out AMFFileData amfFileData)
        {
            amfFileData = null;
            try
            {
                var streamReader = new StreamReader(stream);
                var amfDeserializer = new XmlSerializer(typeof (AMFFileData));
                amfFileData = (AMFFileData) amfDeserializer.Deserialize(streamReader);
                amfFileData.Name = getNameFromStream(stream);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Unable to read AMF file:" + exception);
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Tries the zipped XML read.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="amfFileData">The amf file data.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal static bool TryZippedXMLRead(Stream stream, out AMFFileData amfFileData)
        {
            throw new NotImplementedException();
        }

        internal static bool Save(Stream stream, IList<TessellatedSolid> solids)
        {
            throw new NotImplementedException();
        }
    }
}