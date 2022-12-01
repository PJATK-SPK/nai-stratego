# Authors: Sandro Sobczynski, Marcel Pankanin

from utils.data_parser import DataParser
from mlxtend.plotting import plot_decision_regions
from sklearn import svm, model_selection, decomposition, metrics
import numpy as np
import matplotlib.pyplot as plt


def execute(filename, c, gamma):
    """
        Execute SVM algorithm.

        Parameters:
        filename (str): dataset file name
        c(str): regularization of the model. It only takes positive values.
        gamma(str): controls the effects of each support vector in an SVM model.

        Returns: 
        str: score of the model
    """

    x, y = DataParser().parse(filename)

    train_x, test_x, train_y, test_y = model_selection.train_test_split(
        np.array(x), np.array(y))

    svc = svm.SVC(kernel='rbf', C=c, gamma=gamma)
    svc.fit(train_x, train_y)

    y_prediction = svc.predict(test_x)  # check the outcome of the test data
    print(f"Analysis of: {filename}")
    print(f"Model: {y_prediction[0:10]}")
    print(f"Goal: {test_y[0:10]}")

    """
    Simplify the visualization: https://www.aifinesse.com/svm/support-vector-machine-example-iris/
    """
    pca = decomposition.PCA(2)
    train_x_pca = pca.fit_transform(train_x)
    svc.fit(train_x_pca, train_y)
    plot_decision_regions(train_x_pca, train_y, clf=svc)
    plt.title("Data after PCA decomposition")
    plt.show()

    return metrics.accuracy_score(test_y, y_prediction)


if __name__ == "__main__":
    wheat_seeds_score = execute('wheat-seeds.csv', 1, 1/7)
    print(f"Wheat seeds score: {wheat_seeds_score}")

    hayes_roth = execute('hayes-roth.csv', 2, 1/5)
    print(f"Hayes-Roth score: {hayes_roth}")
