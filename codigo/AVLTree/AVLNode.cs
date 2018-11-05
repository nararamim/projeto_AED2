
namespace AVLTree 
{
    public sealed class AvlNode<@int, @string>
	{
		public AvlNode<@int, @string> Parent;
		public AvlNode<@int, @string> Left;
		public AvlNode<@int, @string> Right;
		public @int Key;
		public @string Value;
		public int Balance;
    }

}