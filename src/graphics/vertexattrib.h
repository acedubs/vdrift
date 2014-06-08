/************************************************************************/
/*                                                                      */
/* This file is part of VDrift.                                         */
/*                                                                      */
/* VDrift is free software: you can redistribute it and/or modify       */
/* it under the terms of the GNU General Public License as published by */
/* the Free Software Foundation, either version 3 of the License, or    */
/* (at your option) any later version.                                  */
/*                                                                      */
/* VDrift is distributed in the hope that it will be useful,            */
/* but WITHOUT ANY WARRANTY; without even the implied warranty of       */
/* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the        */
/* GNU General Public License for more details.                         */
/*                                                                      */
/* You should have received a copy of the GNU General Public License    */
/* along with VDrift.  If not, see <http://www.gnu.org/licenses/>.      */
/*                                                                      */
/************************************************************************/

#ifndef VERTEX_ATTRIB_H
#define VERTEX_ATTRIB_H

namespace VertexAttrib
{
	struct Format
	{
		int index;	// attribute id
		int size;	// 1 to 4 components
		int type;	// component type GL_BYTE, GL_SHORT, GL_FLOAT ...
		int offset;	// attribute offset in the vertex
		bool norm;	// normalize attribute to the range [-1, 1] or [0, 1]
	};

	enum Enum
	{
		VertexPosition,
		VertexNormal,
		VertexTangent,
		VertexBitangent,
		VertexTexCoord,
		VertexBlendIndices,
		VertexBlendWeights,
		VertexColor,
	};

	static const char * const str[] =
	{
		"VertexPosition",
		"VertexNormal",
		"VertexTangent",
		"VertexBitangent",
		"VertexTexCoord",
		"VertexBlendIndices",
		"VertexBlendWeights",
		"VertexColor",
	};
}

#endif
