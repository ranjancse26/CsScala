﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace CsScala
{
	static class WriteDoStatement
	{
		public static void Go(ScalaWriter writer, DoStatementSyntax statement)
		{
			var info = new LoopInfo(statement);

			info.WritePreLoop(writer);
			writer.WriteLine("do");
			writer.WriteOpenBrace();
			info.WriteLoopOpening(writer);

			if (statement.Statement is BlockSyntax)
				foreach (var s in statement.Statement.As<BlockSyntax>().Statements)
					Core.Write(writer, s);
			else
				Core.Write(writer, statement.Statement);

			info.WriteLoopClosing(writer);
			writer.WriteCloseBrace();

			writer.WriteIndent();
			writer.Write("while (");
			Core.Write(writer, statement.Condition);
			writer.Write(");\r\n");
			info.WritePostLoop(writer);
		}
	}
}
