using System;
using System.Collections.Generic;
using System.Text;

namespace XaeiO.Compiler.CodeModel
{
	public class PhiExpression : IExpression
	{
        private IExpression _then;

        public IExpression Then
        {
            get { return _then; }
            set { _then = value; }
        }
        private IExpression _else;

        public IExpression Else
        {
            get { return _else; }
            set { _else = value; }
        }

        private IAssignStatement _condition;

        public IAssignStatement Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public PhiExpression()
        {
        }

        public PhiExpression(IExpression then, IExpression elseExpression)
        {
            Then = then;
            Else = elseExpression;
        }
        public PhiExpression(IExpression then, IExpression elseExpression, IAssignStatement condition)
        {
            Then = then;
            Else = elseExpression;
            Condition = condition;
        }

        public override string ToString()
        {
            return "Φ(" + Then.ToString() + "," + Else.ToString() + ")";
        }

        public override bool Equals(object obj)
        {
            PhiExpression phiExpression = obj as PhiExpression;
            if (phiExpression == null)
            {
                return false;
            }
            return phiExpression.Then.Equals(Then) && phiExpression.Else.Equals(Else);
        }

        #region IExpression Members

        public Mono.Cecil.TypeReference Type
        {
            get
            {
                return Then.Type;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion
    }
}
