import matplotlib.pyplot as plt
import numpy as np
from sklearn import decomposition
from sklearn.metrics import classification_report
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from utils.data_parser import DataParser


def show_data(classifier, x, y, title):
    """
        Show pyplot with given darta.

        Parameters:
        classifier (DecisionTreeClassifier): sklearn classifier
        x(list): x data (inputs)
        y(list): y data (outputs)
        title(str): Plot title
    """
    min_x, max_x = x[:, 0].min() - 1.0, x[:, 0].max() + 1.0
    min_y, max_y = x[:, 1].min() - 1.0, x[:, 1].max() + 1.0

    mesh_step_size = 0.01

    x_vals, y_vals = np.meshgrid(np.arange(
        min_x, max_x, mesh_step_size), np.arange(min_y, max_y, mesh_step_size))

    output = classifier.predict(np.c_[x_vals.ravel(), y_vals.ravel()])
    output = output.reshape(x_vals.shape)

    plt.figure()
    plt.title(title)
    plt.pcolormesh(x_vals, y_vals, output, cmap=plt.cm.gray)

    plt.scatter(x[:, 0], x[:, 1], c=y, s=75, edgecolors='black',
                linewidth=1, cmap=plt.cm.Paired)

    plt.xlim(x_vals.min(), x_vals.max())
    plt.ylim(y_vals.min(), y_vals.max())

    plt.yticks(
        (np.arange(int(x[:, 1].min() - 1), int(x[:, 1].max() + 1), 1.0)))

    plt.show()


def execute_tree(filename):
    """
        Execute DecisionTreeClassifier algorithm and show/print results

        Parameters:
        filename (str): dataset file name
    """
    x, y = DataParser().parse(filename)
    y = np.array(y)

    # Reduce X dimensionality to 2
    pca = decomposition.PCA(2)
    x = pca.fit_transform(x)

    class_1 = np.array(x[y == 1])
    class_2 = np.array(x[y == 2])
    class_3 = np.array(x[y == 3])

    x_train, x_test, y_train, y_test = train_test_split(x, y, random_state=5)

    # Decision trees classifier
    params = {'random_state': 0, 'max_depth': 8}
    classifier = DecisionTreeClassifier(**params)
    classifier.fit(x_train, y_train)

    y_prediction = classifier.predict(x_test)

    # Evaluate classifier performance
    class_names = ['Class 0', 'Class 1', 'Class 2']

    print("\n---\n")
    print("Training performance\n")
    print(classification_report(y_train, classifier.predict(
        x_train), target_names=class_names))
    print("\n")

    print("\n---\n")
    print("Test performance\n")
    print(classification_report(y_test, y_prediction, target_names=class_names))
    print("\n---\n")

    # Input data plot configuration
    plt.figure()
    plt.scatter(class_1[:, 0], class_1[:, 1], s=75,
                facecolors='black', linewidth=1, marker='x')
    plt.scatter(class_2[:, 0], class_2[:, 1], s=75,
                facecolors='white', linewidth=1, marker='o')
    plt.scatter(class_3[:, 0], class_3[:, 1], s=75,
                facecolors='red', linewidth=1, marker='+')
    plt.title('Input')

    plt.show()
    show_data(classifier, x_train, y_train, 'Training data')
    show_data(classifier, x_test, y_test, 'Test data')


if __name__ == "__main__":
    execute_tree('wheat-seeds.csv')
    execute_tree('hayes-roth.csv')
    print("Finish")
