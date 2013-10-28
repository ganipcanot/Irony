﻿#region License
/* **********************************************************************************
 * Copyright (c) Roman Ivantsov
 * This source code is subject to terms and conditions of the MIT License
 * for Irony. A copy of the license can be found in the License.txt file
 * at the root of this distribution. 
 * By using this source code in any fashion, you are agreeing to be bound by the terms of the 
 * MIT License.
 * You must not remove this notice from this software.
 * **********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;
using Irony.Ast;

namespace Irony.Ast.Interpreter {

  public class Closure {
    public string MethodName; //either BindingInfo.Name, or name of the variable storing lambda expression 
    public readonly StackFrame ParentFrame;
    public readonly AstNode Node;
    public readonly FunctionBindingInfo BindingInfo;
    public Closure(StackFrame parentFrame, AstNode node, FunctionBindingInfo bindingInfo) {
      MethodName = bindingInfo.Name;
      ParentFrame = parentFrame;
      Node = node; 
      BindingInfo = bindingInfo;
    }
    public void Evaluate(EvaluationContext context) {
      context.PushFrame(MethodName, Node, ParentFrame);
      try {
      } finally {
        context.PopFrame();
      }//finally
    }//method

  }//class



}//namespace