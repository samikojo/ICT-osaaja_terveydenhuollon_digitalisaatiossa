// Interface määrittää, mitä ominaisuuksia interfacen toteuttavan
// luokan on pakko toteuttaa.
public interface ICharacter
{
	float Height { get; }
	void CollectCoin(int score);
}
