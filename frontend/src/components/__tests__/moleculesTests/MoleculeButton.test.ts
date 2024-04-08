import { mount } from '@vue/test-utils'
import MoleculeButton from '../../molecules/MoleculeButton.vue'
import { describe, expect, test } from 'vitest'

describe(MoleculeButton, () => {
  const slotText = 'Text'
  const wrapper = mount(MoleculeButton, {
    slots: {
      default: slotText
    }
  })
  test('Renders button with provided text and correct style', async () => {
    
    // Verifica se o componente está sendo renderizado
    expect(wrapper.exists()).toBe(true)
    const button = wrapper.find('button')

    // Verifica se a classe do botão está presente e correta
    expect(button.exists()).toBe(true)
    expect(button.classes()).toContain('ContainerButton')

    // Verifica se o texto dentro do botão está correto
    expect(button.text()).toBe(slotText)
  })

  test('Emits "action" event when button is clicked', async () => {
    
    // Simula o clique no botão
    await wrapper.find('button').trigger('click');

    // Verifica se o evento "action" foi emitido
    expect(wrapper.emitted('action')).toBeTruthy();
  })
})
