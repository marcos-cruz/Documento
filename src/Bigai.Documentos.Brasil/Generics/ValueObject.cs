using System;
using System.Reflection;

namespace Bigai.Documentos.Brasil.Generics
{
    /// <summary>
    /// <c>ValueObject</c> representa um objeto de valor genérico, com métodos para comparação e hascode.
    /// </summary>
    /// <typeparam name="TObject">Classe que representa um objeto de valor.</typeparam>
    public abstract class ValueObject<TObject> where TObject : ValueObject<TObject>
    {
        #region Construtor

        /// <summary>
        /// Construtor default.
        /// </summary>
        protected ValueObject() { }

        #endregion

        #region Métodos de Comparação

        /// <summary>
        /// Determina se o objeto especificado no parâmetro é igual ao objeto corrente.
        /// </summary>
        /// <param name="obj">Objeto de valor para ser comparado com o objeto de valor corrente.</param>
        /// <returns>Retorna <c>true</c> se o objeto especificado no parâmetro for igual ao objeto corrente, caso contrário <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            TObject valueObject = obj as TObject;

            if (ReferenceEquals(null, valueObject))
            {
                return false;
            }

            if (ReferenceEquals(this, valueObject))
            {
                return true;
            }

            if (valueObject.GetType() != GetType())
            {
                return false;
            }

            return EqualsCore(valueObject);
        }

        /// <summary>
        /// Determina se o objeto especificado no parâmetro é igual ao objeto corrente, através da comparação específica 
        /// implementada pela classe que herda de <see cref="ValueObject{TObject}"/> e implementa a comparação core.
        /// </summary>
        /// <param name="obj">Objeto de valor para ser comparado com o objeto de valor corrente.</param>
        /// <returns>Retorna <c>true</c> se o objeto especificado no parâmetro for igual ao objeto corrente, caso contrário <c>false</c>.</returns>
        protected abstract bool EqualsCore(TObject obj);

        #endregion

        #region Hashcode

        /// <summary>
        /// Obtém um hash code para o objeto de valor corrente.
        /// </summary>
        /// <returns>Retorna um hash code para o objeto de valor corrente.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return GetHashCodeFromProperties() + GethashCodeFromFields();
            }
        }

        /// <summary>
        /// Obtém um hash code das propriedades públicas do objeto corrente.
        /// </summary>
        /// <returns>Retorna um hash code para as propriedades do objeto de valor corrente.</returns>
        private int GetHashCodeFromProperties()
        {
            unchecked
            {
                int hash = 7;
                Type type = GetType();
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                foreach (PropertyInfo property in properties)
                {
                    //if (!type.GetProperty(property.Name).GetGetMethod().IsVirtual)
                    {
                        hash = HashValue(hash, property.GetValue(this, null));
                    }
                }

                return hash;
            }
        }

        /// <summary>
        /// Obtém um hash code dos campos públicos do objeto corrente.
        /// </summary>
        /// <returns>Retorna um hash code para os campos do objeto de valor corrente.</returns>
        private int GethashCodeFromFields()
        {
            unchecked
            {
                int hash = 7;
                Type type = GetType();
                FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);

                foreach (FieldInfo field in fields)
                {
                    hash = HashValue(hash, field.GetValue(this));
                }

                return hash;
            }
        }

        /// <summary>
        /// Obtém um hash code para um objeto valor.
        /// </summary>
        /// <param name="semente">Valor para ser aplicado na geração do hash code.</param>
        /// <param name="valor">Valor para ser calculado o hash code.</param>
        /// <returns>Retorna um hash code para o objeto de valor corrente.</returns>
        private int HashValue(int semente, object valor)
        {
            unchecked
            {
                int hash = valor != null ? valor.GetHashCode() : 0;

                return semente * 31 + hash;
            }
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Determina se dois objetos de valores são iguais.
        /// </summary>
        /// <param name="objA">Objeto de valor para comparação.</param>
        /// <param name="objB">Objeto de valor para comparação.</param>
        /// <returns>Retorna <c>true</c> se os objetos de valor forem iguais, caso contrário <c>false</c>.</returns>
        public static bool operator ==(ValueObject<TObject> objA, ValueObject<TObject> objB)
        {
            if (ReferenceEquals(objA, null) && ReferenceEquals(objB, null))
            {
                return true;
            }

            if (ReferenceEquals(objA, null) || ReferenceEquals(objB, null))
            {
                return false;
            }

            return objA.Equals(objB);
        }

        /// <summary>
        /// Determina se dois objetos de valores são diferentes.
        /// </summary>
        /// <param name="objA">Objeto de valor para comparação.</param>
        /// <param name="objB">Objeto de valor para comparação.</param>
        /// <returns>Retorna <c>true</c> se os objetos de valor forem diferentes, caso contrário <c>false</c>.</returns>
        public static bool operator !=(ValueObject<TObject> objA, ValueObject<TObject> objB)
        {
            return !(objA == objB);
        }

        #endregion
    }
}
